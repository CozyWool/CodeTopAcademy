package com.demo.coffeeshop.controllers;

import com.demo.coffeeshop.models.Clients;
import com.demo.coffeeshop.services.CafeDiscountManager;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

import java.util.List;

@Controller
public class CafeController {
    private final CafeDiscountManager cafeDiscountManager;

    public CafeController(CafeDiscountManager cafeDiscountManager) {
        this.cafeDiscountManager = cafeDiscountManager;
    }

    @GetMapping("/clients")
    public String getClientsInfo(Model model) {
        List<Clients> minDiscountClients = cafeDiscountManager.getClientsWithMinimumDiscount();
        int minDiscount = minDiscountClients.isEmpty() ? 0 : minDiscountClients.getFirst().getDiscount();

        List<Clients> maxDiscountClients = cafeDiscountManager.getClientsWithMaximumDiscount();
        int maxDiscount = maxDiscountClients.isEmpty() ? 0 : maxDiscountClients.getFirst().getDiscount();

        model.addAttribute("minDiscountClients", minDiscountClients);
        model.addAttribute("maxDiscountClients", maxDiscountClients);

        Clients youngestClient = cafeDiscountManager.getYoungestClient();
        model.addAttribute("youngestClient", youngestClient);

        Clients oldestClient = cafeDiscountManager.getOldestClient();
        model.addAttribute("oldestClient", oldestClient);

        return "clients";
    }
}
