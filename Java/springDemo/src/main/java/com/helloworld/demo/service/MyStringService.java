package com.helloworld.demo.service;

import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class MyStringService {
    List<String> items = new ArrayList(List.of(
            "строка 1",
            "строка 2",
            "строка 3",
            "строка 4"
    ));

    public List<String> getStrings() {
        return items;
    }

    public void create(String name) {
        items.add(name);
    }
}
