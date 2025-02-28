using System;
using OnlineStore.Components.Pages;
using OnlineStore.Models;

namespace OnlineStore.Data.ProductData;

public class ProductData
{
    public List<Product> kitchenProducts = [new(){
    ProductId=112,
    ProductName="Vegetable Peeler",
    Price=130,
    Date=null,
    HowManyProduct=5,
    ImagePath="/images/kitchen/Peeler.png",
    ProductType="kitchen"
},
new(){
    ProductId=3221,
    ProductName="Food Storage Containers (Premium)",
    Price=500,
    Date=null,
    HowManyProduct=3,
    ProductType="kitchen",
    ImagePath="/images/kitchen/can.png"
},
new(){
    ProductId=11111,
    ProductType="kitchen",
    ProductName="Sponges",
    Price=59,
    Date=null,
    HowManyProduct=157,
    ImagePath="/images/kitchen/Sponges.png"
},
new(){
    ProductId=121212,
    ProductName="Large Trash Bin",
    Price=549,
    Date=null,
    ProductType="kitchen",
    HowManyProduct=7,
    ImagePath="/images/kitchen/Trash.png"
},
new(){
    ProductId=989252,
    ProductType="kitchen",
    ProductName="Whisk",
    Price=120,
    Date=null,
    HowManyProduct=13,
    ImagePath="/images/kitchen/Whisk.png"
},
new(){
    ProductId=0192930393,
    ProductName="Can Opener",
    Price=150,
    Date=null,
    HowManyProduct=12,
    ProductType="kitchen",
    ImagePath="/images/kitchen/opeaner.png"

}
,
new(){
    ProductId=341434,
    ProductName="Shears",
    Price=50,
    Date=null,
    HowManyProduct=2,
    ProductType="kitchen",
    ImagePath="/images/kitchen/Shears.png"
},
new(){
    ProductId=765875423,
    ProductName="Colander",
    Price=350,
    Date=null,
    HowManyProduct=9,
    ProductType="kitchen",
    ImagePath="/images/kitchen/Colander.png"
},
new(){
    Date=null,
    Price=559,
    ProductId=12312312,
    ProductName="Grill Pan",
    HowManyProduct=7,
    ProductType="kitchen",
    ImagePath="/images/kitchen/Grill.png"
}
];


    public List<Product> beautyPublic = [
    new(){
    ProductId=11111,
    ProductName="Bella Fragrance",
    Price=1599,
    Date=null,
    ProductType="beauty",
    HowManyProduct=7, ImagePath="/images/beauty/Bella.png"
},new(){
    ProductId=12111,
    ProductName="CeraVe",
    Price=3400,
    Date=null,
    ProductType="beauty",
    HowManyProduct=4, ImagePath="/images/beauty/CeraVe.png"
},new(){
    ProductId=13111,
    ProductName="Note Real Look",
    Price=1450,
    Date=null,
    ProductType="beauty",
    HowManyProduct=2, ImagePath="/images/beauty/Eye.png"
},new(){
    ProductId=14111,
    ProductName="ForEver52 Foundation",
    Price=1520,
    Date=null,
    ProductType="beauty",
    HowManyProduct=17, ImagePath="/images/beauty/Forever52.png"
},new(){
    ProductId=15111,
    ProductName="Urban Care Style Guide Elastic Curl Hair Gel 150ml",
    Price=1490,
    Date=null,
    ProductType="beauty",
    HowManyProduct=10, ImagePath="/images/beauty/Hair.png"
},new(){
    ProductId=16111,
    ProductName="Earth Rhythm Hair Butter - Onion, Fenugreek & Cocoa Butter - 100 Ml",
    Price=1305,
    Date=null,
    ProductType="beauty",
    HowManyProduct=1, ImagePath="/images/beauty/HairButter.png"
}
    ];
}