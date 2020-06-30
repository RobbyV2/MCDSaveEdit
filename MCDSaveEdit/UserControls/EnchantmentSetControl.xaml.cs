﻿using DungeonTools.Save.Models.Enums;
using DungeonTools.Save.Models.Profiles;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
#nullable enable

namespace MCDSaveEdit
{
    /// <summary>
    /// Interaction logic for EnchantmentSetControl.xaml
    /// </summary>
    public partial class EnchantmentSetControl : UserControl
    {
        public EnchantmentSetControl()
        {
            InitializeComponent();
            backgroundImage.Source = ImageUriHelper.instance.imageSource("/Dungeons/Content/UI/Materials/StatusEffect/Enchantment/EnchantmentsBackground");
            topEnchantmentSymbolImage.Source = ImageUriHelper.instance.imageSource("/Dungeons/Content/UI/Materials/Mobs/enchant_common_icon");
            updateUI();
        }

        private Enchantment[]? _enchantments;
        public IEnumerable<Enchantment>? enchantments
        {
            get { return _enchantments; }
            set { _enchantments = value?.ToArray(); updateUI(); }
        }

        public void clearAll()
        {
            enchantment1Image.Source = null;
            enchantment1Button.CommandParameter = null;
            enchantment2Image.Source = null;
            enchantment2Button.CommandParameter = null;
            enchantment3Image.Source = null;
            enchantment3Button.CommandParameter = null;
            upgradedEnchantmentButton.Visibility = Visibility.Visible;
            upgradedEnchantmentImage.Source = ImageUriHelper.instance.imageSourceForEnchantment(EnchantmentType.Unset);
            upgradedEnchantmentButton.CommandParameter = null;
        }
        public void updateUI()
        {
            if(_enchantments == null || _enchantments.Length == 0)
            {
                clearAll();
                return;
            }

            var upgradedEnchantment = _enchantments.FirstOrDefault(x => x.Level > 0);
            if(upgradedEnchantment != null)
            {
                enchantment1Image.Source = null;
                enchantment1Button.CommandParameter = null;
                enchantment2Image.Source = null;
                enchantment2Button.CommandParameter = null;
                enchantment3Image.Source = null;
                enchantment3Button.CommandParameter = null;
                upgradedEnchantmentButton.Visibility = Visibility.Visible;
                upgradedEnchantmentImage.Source = ImageUriHelper.instance.imageSourceForEnchantment(upgradedEnchantment.Type);
                upgradedEnchantmentButton.CommandParameter = upgradedEnchantment;
            }
            else
            {
                enchantment1Image.Source = ImageUriHelper.instance.imageSourceForEnchantment(_enchantments[0].Type);
                enchantment1Button.CommandParameter = _enchantments[0];
                enchantment2Image.Source = ImageUriHelper.instance.imageSourceForEnchantment(_enchantments[1].Type);
                enchantment2Button.CommandParameter = _enchantments[1];
                enchantment3Image.Source = ImageUriHelper.instance.imageSourceForEnchantment(_enchantments[2].Type);
                enchantment3Button.CommandParameter = _enchantments[2];
                upgradedEnchantmentButton.Visibility = Visibility.Collapsed;
                upgradedEnchantmentImage.Source = null;
                upgradedEnchantmentButton.CommandParameter = null;
            }
        }

        private ICommand? _command;
        public ICommand? command
        {
            get { return _command; }
            set { _command = value; updateCommand(); }
        }

        public void updateCommand()
        {
            enchantment1Button.Command = _command;
            enchantment2Button.Command = _command;
            enchantment3Button.Command = _command;
            upgradedEnchantmentButton.Command = _command;
        }
    }
}
