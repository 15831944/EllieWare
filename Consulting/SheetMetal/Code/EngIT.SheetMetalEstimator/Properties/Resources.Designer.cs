﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EngIT.SheetMetalEstimator.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("EngIT.SheetMetalEstimator.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Estimate all sheet metal parts in a folder.
        /// </summary>
        internal static string BatchHint {
            get {
                return ResourceManager.GetString("BatchHint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to BATCH ESTIMATE.
        /// </summary>
        internal static string BatchText {
            get {
                return ResourceManager.GetString("BatchText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to EngIT Sheet Metal Estimator.
        /// </summary>
        internal static string ManagerGroupText {
            get {
                return ResourceManager.GetString("ManagerGroupText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;customUI xmlns=&quot;http://schemas.spaceclaim.com/customui&quot;&gt;
        ///  &lt;!--
        ///  //
        ///  //  Copyright (C) 2013 EllieWare
        ///  //
        ///  //  All rights reserved
        ///  //
        ///  //  www.EllieWare.com
        ///  //
        ///  --&gt;
        ///  &lt;ribbon&gt;
        ///    &lt;tabs&gt;
        ///      &lt;tab id=&quot;EngIT.RibbonTab&quot; command=&quot;EngIT.RibbonTab&quot;&gt;
        ///        &lt;!-- 
        ///          For the &apos;tab&apos; and &apos;group&apos; elements, you can either specify a &apos;label&apos; attribute, or you can
        ///          specify a &apos;command&apos; attribute.  The &apos;command&apos; attribute gives the name of a [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Ribbon {
            get {
                return ResourceManager.GetString("Ribbon", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to EngIT Sheet Metal Estimator.
        /// </summary>
        internal static string RibbonTabText {
            get {
                return ResourceManager.GetString("RibbonTabText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sheet metal estimate active part.
        /// </summary>
        internal static string SingleHint {
            get {
                return ResourceManager.GetString("SingleHint", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PART ESTIMATE.
        /// </summary>
        internal static string SingleText {
            get {
                return ResourceManager.GetString("SingleText", resourceCulture);
            }
        }
        
        internal static System.Drawing.Bitmap sm_estimate_current_part_32x32 {
            get {
                object obj = ResourceManager.GetObject("sm_estimate_current_part_32x32", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap sm_estimate_folder_32x32 {
            get {
                object obj = ResourceManager.GetObject("sm_estimate_folder_32x32", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
