using Elements;
using System.Collections.Generic;
using System;
using System.Linq;

namespace HyparControlDisplayDemo
{
	/// <summary>
	/// Override metadata for ProfilesOverrideRemoval
	/// </summary>
	public partial class ProfilesOverrideRemoval : IOverride
	{
        public static string Name = "Profiles Removal";
        public static string Dependency = null;
        public static string Context = "[*discriminator=Elements.DemoElement]";
		public static string Paradigm = "Edit";

        /// <summary>
        /// Get the override name for this override.
        /// </summary>
        public string GetName() {
			return Name;
		}

		public object GetIdentity() {

			return Identity;
		}

	}

}