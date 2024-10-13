using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace Lab1._1Ver.Models
{
    public class SeriesSumModel
    {
        [Required(ErrorMessage = "Поле X обязательно для заполнения")]
        [Range(-1.9999999999999, 1.999999999999, ErrorMessage = "Значение X должно быть строго больше -2 и меньше 2.")]
        [Display(Name = "Значение X")]
        [ModelBinder(BinderType = typeof(CustomDoubleModelBinder))]
        public double X { get; set; }

        [Required(ErrorMessage = "Поле Точность ε обязательно для заполнения")]
        [Range(0.000001, double.MaxValue, ErrorMessage = "Точность ε должна быть больше 0.000001.")]
        [Display(Name = "Точность ε")]
        [ModelBinder(BinderType = typeof(CustomDoubleModelBinder))]
        public double Epsilon { get; set; }

        public double? Result { get; set; }
        public int? TermsUsed { get; set; }
        public List<double>? TermsUsedValues { get; set; }
    }
}

