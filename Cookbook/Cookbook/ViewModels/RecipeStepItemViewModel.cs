using Cookbook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.ViewModels
{
    internal class RecipeStepItemViewModel : BaseViewModel
    {
        private string _text;
        private string _stepImage;
        public RecipeStepItemViewModel(Recipe recipe)
        {

            //Text = recipe.Text;
            //_text = recipe.Steps.ToString();
        }
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
        public string StepImage
        {
            get => _stepImage;
            set
            {
                _stepImage = value;
                OnPropertyChanged(nameof(StepImage));
            }
        }

    }
}
