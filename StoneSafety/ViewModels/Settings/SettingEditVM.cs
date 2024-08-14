using System.ComponentModel.DataAnnotations;

namespace StoneSafety.ViewModels.Settings
{
    public class SettingEditVM
    {
        [Required]
        public string Value { get; set; }
    }
}
