package com.helloworld.demo;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
public class HelloController {

    @RequestMapping("/hello")
    public String getHello(@RequestParam(value = "name", defaultValue = "world") String name) {
        return "Hello " + name;
    }

    @RequestMapping(value = "/send", method = RequestMethod.POST)
    public ResponseEntity<String> sendValue(@RequestBody String value) {
        return new ResponseEntity<String>(value, HttpStatus.CREATED);
    }
}
