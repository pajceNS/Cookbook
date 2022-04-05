using Cookbook.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Cookbook.ViewModels
{
    internal class RecipeStepItemViewModel : BaseViewModel
    {
        private string _text;
        private string _stepImage;
        private string _name;
        private string _unit;
        private string _amount;
        private int _stepCounter;
        private bool _isStepTextLabelVisible;
        public RecipeStepItemViewModel(Step step)
        {
            if(step.Text != null)
            {
                Text = step.Text;
                IsStepTextLabelVisible = true ;
            }
            else
            {
                IsStepTextLabelVisible= false ;
            }
            StepImage = step.Image;
            


            _stepCounter = Preferences.Get("stepCounter",0);
            Preferences.Set("stepCounter", ++_stepCounter);

        }
        public RecipeStepItemViewModel(Ingredient ingredient)
        {
            _name = ingredient.Name;
            _amount = ingredient.Amount;
            if(ingredient.Unit == null)
            {
                _unit = "/";
            }else _unit = ingredient.Unit;


        }
        public bool IsStepTextLabelVisible
        {
            get => _isStepTextLabelVisible;
            set
            {
                _isStepTextLabelVisible = value;
                OnPropertyChanged(nameof(IsStepTextLabelVisible));
            }
        }
        public int StepCounter
        {
            get => _stepCounter;
            set
            {
                _stepCounter = value;
                OnPropertyChanged(nameof(StepCounter));
            }
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
