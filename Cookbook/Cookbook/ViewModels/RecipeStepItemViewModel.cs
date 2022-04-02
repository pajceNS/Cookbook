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
        private string _name;
        private string _unit;
        private string _amount;
        public RecipeStepItemViewModel(Step step)
        {
            _text = step.Text;
            _stepImage = step.Image;
        }
        public RecipeStepItemViewModel(Ingredient ingredient)
        {
            _name = ingredient.Name;
            _amount = ingredient.Amount;
            _unit = ingredient.Unit;

        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Unit
        {
            get => _unit;
            set
            {
                _unit = value;
                OnPropertyChanged(nameof(Unit));
            }
        }

        public string Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
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
