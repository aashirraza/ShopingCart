﻿namespace SC.Business.Model
{
    public class ProductModel
    {
        public ProductModel() 
        {
            Store = new StoreModel();
        }
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Catagory { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int StoreId { get; set; }
        public StoreModel Store { get; set; }
    }
}