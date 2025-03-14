package com.exam.sportShop.controllers;


import com.exam.sportShop.models.Product;
import com.exam.sportShop.services.ProductService;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;

@Controller
@RequestMapping("/products")
public class ProductController {

    private final ProductService productService;

    public ProductController(ProductService ProductService) {
        this.productService = ProductService;
    }

    @GetMapping
    public String getAll(Model model,
                         @RequestParam(required = false) String title,
                         @RequestParam(required = false) String brand,
                         @RequestParam(required = false) Long price,
                         @RequestParam(required = false) String size,
                         @RequestParam(required = false) String color,
                         @RequestParam(required = false) String category) {
        var result = productService.getProducts(title, brand, price, size, color, category);
        model.addAttribute("items", result);
        return "index";
    }

    @GetMapping("/{id}")
    public String getById(@PathVariable long id, Model model) {
        var result = productService.getById(id);
        model.addAttribute("item", result);
        return "getById";
    }

    @PostMapping
    public String createProduct(@ModelAttribute Product product) {
        productService.create(product);
        return "redirect:/products";
    }

    @PostMapping("/{id}")
    public String updateProduct(@PathVariable Long id, @ModelAttribute Product product) {
        product.setId(id);
        productService.update(product);
        return "redirect:/products/" + id.toString();
    }

    @DeleteMapping("/{id}")
    public String deleteProduct(@PathVariable Long id) {
        productService.delete(id);
        return "redirect:/products";
    }
}
