﻿// Copyright (c) Microsoft Corporation, Inc. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.IO;

namespace System.Web.Optimization {
    /// <summary>
    /// Standalone class for generating bundle responses outside of ASP.NET
    /// </summary>
    public static class Optimizer {
        /// <summary>
        /// Builds a <see cref="BundleResponse"/> object from the declarations found in a bundle manifest file.
        /// </summary>
        /// <param name="bundlePath">The path to the bundle being requested</param>
        /// <param name="settings">An <see cref="OptimizationSettings"/> object containing configuation settings for optimization.</param>
        /// <returns>The bundle response for specified <paramref name="bundlePath"/>.</returns>
        /// <remarks>
        /// The associated <see cref="BundleCollection"/> object is populated from <see cref="OptimizationSettings.BundleManifestPath"/> 
        /// and <see cref="OptimizationSettings.BundleSetupMethod"/> properties of the <paramref name="settings"/> parameter. 
        /// <see cref="OptimizationSettings.ApplicationPath"/>, also a property of <paramref name="settings"/>, must reference the physical 
        /// application file in order to resolve '~' in the virtual paths
        /// </remarks>
        public static BundleResponse BuildBundle(string bundlePath, OptimizationSettings settings) {
            if (settings == null) {
                throw new ArgumentNullException("settings");
            }
            if (String.IsNullOrEmpty(settings.ApplicationPath)) {
                throw ExceptionUtil.ParameterNullOrEmpty("settings.ApplicationPath");
            }
            if (String.IsNullOrEmpty(bundlePath)) {
                throw ExceptionUtil.ParameterNullOrEmpty("bundlePath");
            }

            BundleCollection bundleTable = InitializeBundleCollection(settings);
            FileVirtualPathProvider vpp = new FileVirtualPathProvider(settings.ApplicationPath);
            BundleContext context = new BundleContext();
            context.VirtualPathProvider = vpp;
            context.BundleCollection = bundleTable;
            context.BundleVirtualPath = bundlePath;

            Bundle bundle = bundleTable.GetBundleFor(bundlePath);
            if (bundle != null) {
                return bundle.GetBundleResponse(context);
            }

            return null;
        }

        private static BundleCollection InitializeBundleCollection(OptimizationSettings settings) {
            BundleCollection bundleTable = settings.BundleTable ?? new BundleCollection();

            // Setup the bundle table first with manifest
            if (!String.IsNullOrEmpty(settings.BundleManifestPath)) {
                using (var stream = File.OpenRead(settings.BundleManifestPath)) {
                    BundleManifest manifest = BundleManifest.ReadBundleManifest(stream);
                    manifest.Register(bundleTable);
                }
            }
            // Invoke the setup method second so code wins (i.e. BundleConfig.RegisterBundles)
            if (settings.BundleSetupMethod != null) {
                settings.BundleSetupMethod(bundleTable);
            }

            return bundleTable;
        }

        /// <summary>
        /// Builds all bundles in the settings.BundleCollection, primarily intended to fill the bundle collections cache
        /// Note: this will just skip any dynamic folder bundles
        /// </summary>
        /// <param name="settings"></param>
        public static void BuildAllBundles(OptimizationSettings settings) {
            if (settings == null) {
                throw new ArgumentNullException("settings");
            }
            if (String.IsNullOrEmpty(settings.ApplicationPath)) {
                throw ExceptionUtil.ParameterNullOrEmpty("settings.ApplicationPath");
            }

            FileVirtualPathProvider vpp = new FileVirtualPathProvider(settings.ApplicationPath);
            BundleCollection bundleTable = InitializeBundleCollection(settings);

            foreach (Bundle bundle in bundleTable) {
                // DynamicFolderBundles are keyed off the request path so they cannot be arbitrarily prebuilt
                if (bundle is DynamicFolderBundle) {
                    continue;
                }

                BundleContext context = new BundleContext();
                context.VirtualPathProvider = vpp;
                context.BundleCollection = bundleTable;
                context.BundleVirtualPath = bundle.Path;
                bundle.GetBundleResponse(context);
            }

        }

    }
}
