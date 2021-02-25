﻿using System;
using System.IO;
using Windows.Management.Deployment;
#nullable enable

namespace MCDSaveEdit
{
    public static partial class Constants
    {
        public const string CURRENT_RELEASE_TAG_NAME = "1.2.7";
        public const string LATEST_RELEASE_URL = "https://github.com/CutFlame/MCDSaveEdit/releases/latest";

        // The application's name used for identification in the registry.
        public const string APPLICATION_NAME = "MCDSaveEdit";
        public const int MAX_RECENT_FILES = 10;

        public const int MAXIMUM_INVENTORY_ITEM_COUNT = 300;

        public const int MINIMUM_ENCHANTMENT_TIER = 0;
        public const int MAXIMUM_ENCHANTMENT_TIER = 3;

        public const int MINIMUM_CHARACTER_LEVEL = 0;
        public const int MAXIMUM_CHARACTER_LEVEL = 1000000000;

        public const int MINIMUM_ITEM_LEVEL = 0;
        public const int MAXIMUM_ITEM_LEVEL = 1000000000;

        public const string EMERALD_CURRENCY_NAME = "Emerald";
        public const string GOLD_CURRENCY_NAME = "Gold";

        public const string PAKS_FILTER_STRING = "/Dungeons/Content";

        public const string FIRST_PAK_FILENAME = "pakchunk0-WindowsNoEditor.pak";

        public static string PAKS_FOLDER_PATH {
            get {
                var appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(appDataFolderPath, "Mojang", "products", "dungeons", "dungeons", "Dungeons", "Content", "Paks");
            }
        }

        public static string? WINSTORE_PAKS_FOLDER_IF_EXISTS {
            get {
                var pm = new PackageManager();
                foreach (var pkg in pm.FindPackagesForUser(string.Empty, "Microsoft.Lovika_8wekyb3d8bbwe"))
                {
                    if (pkg.IsDevelopmentMode) // Only true if run through the script
                    {
                        return Path.Combine(pkg.InstalledLocation.Path, "Dungeons", "Content", "Paks");
                    }
                }
                // Game has not been run through the script, meaning the files are not accessible
                return null;
            }
        }

        public static string FILE_DIALOG_INITIAL_DIRECTORY {
            get {
                var userFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                return Path.Combine(userFolderPath, "Saved Games", "Mojang Studios", "Dungeons");
            }
        }
        public const string ENCRYPTED_FILE_EXTENSION = ".dat";
        public const string DECRYPTED_FILE_EXTENSION = ".json";
    }
}
