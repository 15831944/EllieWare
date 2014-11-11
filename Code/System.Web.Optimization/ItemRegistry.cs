﻿// Copyright (c) Microsoft Corporation, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Hosting;
using System.Web.Optimization.Resources;

namespace System.Web.Optimization {
    internal class ItemRegistry : List<BundleItem> {

        // Unit test hook
        private VirtualPathProvider _vpp;
        internal VirtualPathProvider VirtualPathProvider {
            get {
                return _vpp ?? BundleTable.VirtualPathProvider;
            }
            set {
                _vpp = value;
            }
        }

        internal Bundle Bundle { get; set; }

        public ItemRegistry() {
        }

        /// <summary>
        /// Includes the specified patterns in the order specified
        /// Supports limited wildcards in the last path segment[prefix(*js) or suffix(jquery*) only]
        /// </summary>
        /// <param name="virtualPaths"></param>
        /// <returns></returns>
        internal Exception Include(params string[] virtualPaths) {
            foreach (string virtualPath in virtualPaths) {
                Exception error = IncludePath(virtualPath, null);
                if (error != null) {
                    return error;
                }
            }
            return null;
        }

        internal Exception IncludePath(string virtualPath, params IItemTransform[] transforms) {
            Exception error = ExceptionUtil.ValidateVirtualPath(virtualPath, "virtualPath");
            if (error != null) {
                return error;
            }
            if (virtualPath.Contains('*') || virtualPath.Contains('{')) {
                // Wildcards can only be in the last path segment, and also can only be the first or last char there
                int lastSlash = virtualPath.LastIndexOf('/'); // Guaranteed to be one from above check
                string directoryPath = virtualPath.Substring(0, lastSlash + 1); // Want to keep the trailing / for app root case
                if (directoryPath.Contains('*')) {
                    return new ArgumentException(String.Format(CultureInfo.CurrentCulture, OptimizationResources.InvalidPattern, virtualPath), "virtualPath");
                }
                string searchPattern = "";
                if (lastSlash < virtualPath.Length - 1) {
                    searchPattern = virtualPath.Substring(lastSlash + 1);
                }
                PatternType patternType = PatternHelper.GetPatternType(searchPattern);
                error = PatternHelper.ValidatePattern(patternType, searchPattern, "virtualPath");
                if (error != null) {
                    return error;
                }

                error = IncludeDirectory(directoryPath, searchPattern, patternType, searchSubdirectories: false, transforms: transforms);
                if (error != null) {
                    return error;
                }
            }
            else {
                if (VirtualPathProvider == null || VirtualPathProvider.FileExists(virtualPath)) {
                    Add(new BundleItem(virtualPath, transforms));
                }
            }
            return null;
        }

        internal Exception IncludeDirectory(string directoryVirtualPath, string searchPattern, PatternType patternType, bool searchSubdirectories, params IItemTransform[] transforms) {
            Exception error = ExceptionUtil.ValidateVirtualPath(directoryVirtualPath, "directoryVirtualPath");
            if (error != null) {
                return error;
            }
            if (ExceptionUtil.IsPureWildcardSearchPattern(searchPattern)) {
                return new ArgumentException(OptimizationResources.InvalidWildcardSearchPattern, "searchPattern");
            }

            if (VirtualPathProvider == null || VirtualPathProvider.DirectoryExists(directoryVirtualPath)) {
                Add(new BundleDirectoryItem(directoryVirtualPath, searchPattern, patternType, searchSubdirectories, transforms));
            }
            else {
                return new ArgumentException(OptimizationResources.BundleDirectory_does_not_exist, "directoryVirtualPath");
            }
            return null;
        }
    }
}
