package com.helloworld.demo;

import com.helloworld.demo.service.MyStringService;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PostMapping;

import java.util.List;

@Controller
public class HomeController {

    private final MyStringService myStringService;

    public HomeController(MyStringService myStringService) {
        this.myStringService = myStringService;
    }

    @GetMapping("/")
    public String index(Model model) {
        var items = myStringService.getStrings();
        model.addAttribute("items", items);
        return "index";
    }

    @PostMapping("/create-item")
    public String createItem(@ModelAttribute(name = "name") String name) {
        myStringService.create(name);
        return "redirect:/";
    }
}
