using System;
using System.Collections.Generic;

class InventoryManagement
{
      // Function
    static List<string> productNames = new List<string>();
    static List<double> productPrices = new List<double>();
    static List<int> productQuantities = new List<int>();

    static void Main(string[] args)
    {
        bool isRunning = true;

      // Loops is running
        while (isRunning)
        {
            Console.WriteLine("\n--- Inventory Management System ---");
            Console.WriteLine("1. Add New Product");
            Console.WriteLine("2. Update Product Stock");
            Console.WriteLine("3. Display All Inventory");
            Console.WriteLine("4. Remove a Product");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");
            
            string choice = Console.ReadLine();

            // Switch direct choice
            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    UpdateStock();
                    break;
                case "3":
                    DisplayInventory();
                    break;
                case "4":
                    RemoveProduct();
                    break;
                case "5":
                    isRunning = false;
                    Console.WriteLine("Exiting program... Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                    break;
            }
        }
    }

    // Add Product
    static void AddProduct()
    {
        Console.WriteLine("\n-- Add Product --");
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();

        double tempNumber;
        if (double.TryParse(name, out tempNumber))
        {
            Console.WriteLine("Error: Product name cannot be just a number!");
            return;
        }

        Console.Write("Enter product price: ");
        string priceInput = Console.ReadLine();
        double price;
        if (!double.TryParse(priceInput, out price))
        {
            Console.WriteLine("Error: Price must be a valid number!");
            return;
        }

        Console.Write("Enter product quantity: ");
        string quantityInput = Console.ReadLine();
        int quantity;
        if (!int.TryParse(quantityInput, out quantity))
        {
            Console.WriteLine("Error: Quantity must be a whole number!");
            return;
        }

        productNames.Add(name);
        productPrices.Add(price);
        productQuantities.Add(quantity);

        Console.WriteLine("Success: Product added successfully!");
    }

    // Update Product
    static void UpdateStock()
    {
        Console.WriteLine("\n-- Update Stock --");
        Console.Write("Enter the name of the product to update: ");
        string name = Console.ReadLine();

        int index = productNames.IndexOf(name);

        if (index == -1) // إذا لم يجد المنتج
        {
            Console.WriteLine("Error: Product not found in inventory.");
            return;
        }

        Console.Write("Enter the new stock quantity: ");
        string quantityInput = Console.ReadLine();
        int newQuantity;
        if (!int.TryParse(quantityInput, out newQuantity))
        {
            Console.WriteLine("Error: Quantity must be a whole number!");
            return;
        }

        productQuantities[index] = newQuantity;
        Console.WriteLine("Success: Stock updated successfully!");
    }

    // View Product
    static void DisplayInventory()
    {
        Console.WriteLine("\n-- Current Inventory --");
        
        if (productNames.Count == 0)
        {
            Console.WriteLine("The inventory is currently empty.");
        }
        else
        {
            for (int i = 0; i < productNames.Count; i++)
            {
                Console.WriteLine($"[{i+1}] Name: {productNames[i]} | Price: ${productPrices[i]} | Quantity in Stock: {productQuantities[i]}");
            }
        }
    }

    // Remove Product
    static void RemoveProduct()
    {
        Console.WriteLine("\n-- Remove Product --");
        Console.Write("Enter the name of the product to remove: ");
        string name = Console.ReadLine();

        int index = productNames.IndexOf(name);

        if (index == -1)
        {
            Console.WriteLine("Error: Product not found in inventory.");
            return;
        }

        // Remove Index
        productNames.RemoveAt(index);
        productPrices.RemoveAt(index);
        productQuantities.RemoveAt(index);

        Console.WriteLine("Success: Product removed entirely from inventory.");
    }
}