using Cookbook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cookbook.ViewModels
{
    internal class RecipeItemViewModel : BaseViewModel
    {
        private string _name;
        private string _shortDescription;
        private string _thumbnailImage;
        private readonly Recipe _recipe;
        private string _type;
        //private string _backgroundImage;
        //private string _longDescription;
        //private string _text;
        //private string _stepImage;
        //private string _unit;
        //private string _ingredientName;
        //private string _amount;
        //private Guid _id;

        public RecipeItemViewModel(Recipe recipe)
        {
            _recipe = recipe;   
            Name = recipe.Name;
            ShortDescription = recipe.ShortDescription;
            ThumbnailImage = recipe.ThumbnailImage;
            Type = recipe.Type;


            //BackgroundImage = recipe.BackgroundImage;
            //LongDescription = recipe.LongDescription;

            //Type = recipe.Type;
            //StepImage = recipe.StepImage;
            //Text = recipe.Text;
            //StepImage = recipe.StepImage;
            //IngedientName = recipe.IngredientName;
            //Unit = recipe.Unit;
            //Amount = recipe.Amount;

        }
        public Recipe Recipe { get; }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string ShortDescription
        {
            get => _shortDescription;
            set
            {
                _shortDescription = value;
                OnPropertyChanged(nameof(ShortDescription));
            }
        }

        public string ThumbnailImage
        {
            get => _thumbnailImage;
            set
            {
                _thumbnailImage = value;
                OnPropertyChanged(nameof(ThumbnailImage));
            }
        }
        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        //public Guid Id
        //{
        //    get => _id;
        //    set
        //    {
        //        _id = value;
        //        OnPropertyChanged(nameof(Id));
        //    }
        //}

        //public string Amount
        //{
        //    get => _amount;
        //    set
        //    {
        //        _amount = value;
        //        OnPropertyChanged(nameof(Amount));
        //    }
        //}
        //public string Unit
        //{
        //    get => _unit;
        //    set
        //    {
        //        _unit = value;
        //        OnPropertyChanged(nameof(Unit));
        //    }
        //}
        //public string IngedientName
        //{
        //    get => _ingredientName;
        //    set
        //    {
        //        _ingredientName = value;
        //        OnPropertyChanged(nameof(IngedientName));
        //    }
        //}
        //public string BackgroundImage
        //{
        //    get => _backgroundImage;
        //    set
        //    {
        //        _backgroundImage = value;
        //        OnPropertyChanged(nameof(BackgroundImage));
        //    }
        //}
        //public string StepImage
        //{
        //    get => _stepImage;
        //    set
        //    {
        //        _stepImage = value;
        //        OnPropertyChanged(nameof(StepImage));
        //    }
        //}
        //public string LongDescription
        //{
        //    get => _longDescription;
        //    set
        //    {
        //        _longDescription = value;
        //        OnPropertyChanged(nameof(LongDescription));
        //    }
        //}
        //public string Text
        //{
        //    get => _text;
        //    set
        //    {
        //        _text = value;
        //        OnPropertyChanged(nameof(Text));
        //    }
        //}

        public Recipe GetRecipe()
        {
            return _recipe;
        }
    }
}
