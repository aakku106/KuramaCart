# KuramaCart 🦊 - Online Shopping Application

## Overview

KuramaCart is an interactive online shopping application built with Blazor , featuring a modern UI design with glassmorphism effects. The application offers a responsive, user-friendly interface for browsing and purchasing various products.

## Features

- **Modern UI Design**: Glassmorphism effects, gradients, and animations for an engaging shopping experience
- **Product Categories**: Dedicated sections for different product types
  - Beauty Products 💄
  - Kitchen Items 🧑🏻‍🍳
  - Clothing 👕
- **Interactive Shopping Cart**: Add/remove products with real-time updates
- **Search Functionality**: Search products across all categories
- **Responsive Layout**: Optimized for mobile and desktop devices
- **Instant Notifications**: Toast notifications for cart actions

## Tech Stack

- **Frontend**: Blazor  with .NET 9.0
- **Styling**: CSS3, Bootstrap 5.3
- **Interactivity**: C# for component logic
- **Icons**: Bootstrap Icons

<!-- ## Project Structure -->

### Key Components

- **Beauty.razor**: Displays beauty products with add-to-cart functionality
- **Kitchen.razor**: Shows kitchen items with a waterfall layout
- **Cart.razor**: Manages the user's shopping cart with remove functionality
- **NavBar.razor**: Navigation bar with search functionality
- **CartData.cs**: Manages cart state and operations
- **ProductData.cs**: Product data and operations

### Directory Structure

```
OnlineStore/
├── Components/
│   ├── Layout/
│   │   ├── MainLayout.razor
│   │   ├── NavBar.razor
│   │   └── PageNotFound.razor
│   ├── Pages/
│   │   ├── Beauty.razor
│   │   ├── Cart.razor
│   │   ├── Cloths.razor
│   │   ├── Home.razor
│   │   ├── Kitchen.razor
│   │   └── LoginPage.razor
│   └── Routes.razor
├── Data/
│   ├── CartData.cs
│   └── ProductData.cs
├── Models/
│   ├── Product.cs
│   └── User.cs
└── wwwroot/
    └── images/
```

## UI Features

### Glassmorphism Design
- Frosted glass effects
- Subtle shadows and gradients
- Semi-transparent backgrounds
- Blur effects

### Interactive Elements
- Hover animations
- Click feedback
- Toast notifications
- Modal confirmations

<!-- ## Screenshots -->


## Getting Started

### Prerequisites
- .NET 9.0 SDK or later
- Visual Studio 2022 or VS Code

### Running the Application
1. Clone the repository 
``` 
    git clone https://github.com/aakku106/KuramaCart.git
 ```
2. Navigate to the project directory ``` ls && cd OnlineStore ```
3. Run `dotnet restore` to restore dependencies ``` dotnet restore ```
4. Run `dotnet run` to start the application or ``` dotnet watch run ```
5. Open your browser and navigate to `https://localhost:5142`

## Future Enhancements

- User authentication and profile management
- Order processing functionality
- Payment integration
- Product reviews and ratings
- Wishlist functionality
- Admin dashboard

## Credits

- Design inspiration: Modern e-commerce platforms
- Icons: Bootstrap Icons library
- Images: Product images from various sources

## License

[Add license information here]