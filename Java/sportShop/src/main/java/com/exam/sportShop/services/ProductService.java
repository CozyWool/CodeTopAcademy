package com.exam.sportShop.services;

import com.exam.sportShop.models.Product;
import com.exam.sportShop.repositories.ProductRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.stream.Collectors;

@Service
public class ProductService {
    private final ProductRepository productRepository;

    @Autowired
    public ProductService(ProductRepository ProductRepository) {
        this.productRepository = ProductRepository;
    }

    public List<Product> getProducts() {
        return productRepository.findAll().stream().sorted((o1, o2) -> Math.toIntExact(o1.getId() - o2.getId())).toList();
    }

    public List<Product> getProducts(String title, String brand, Long price, String size, String color, String category) {
        var products = getProducts();
        var productStream = products.stream();
        if (title != null) {
            productStream = productStream.filter(product -> product.getName().contains(title));
        }
        if (brand != null) {
            productStream = productStream.filter(product -> product.getBrand().contains(brand));
        }
        if (price != null) {
            productStream = productStream.filter(product -> product.getPrice().equals(price));
        }
        if (size != null) {
            productStream = productStream.filter(product -> product.getSize().contains(size));
        }
        if (color != null) {
            productStream = productStream.filter(product -> product.getColor().contains(color));
        }
        if (category != null) {
            productStream = productStream.filter(product -> product.getCategory().contains(category));
        }
        return productStream.collect(Collectors.toList());
    }

    public Product create(Product Product) {
        return productRepository.save(Product);
    }

    public Product update(Product Product) {
        return productRepository.save(Product);
    }

    public void delete(Long id) {
        productRepository.deleteById(id);
    }

    public Product getById(long id) {
        return productRepository.findById(id).orElse(null);
    }

}
