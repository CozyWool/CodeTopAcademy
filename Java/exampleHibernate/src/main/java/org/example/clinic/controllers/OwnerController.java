package org.example.clinic.controllers;


import org.example.clinic.models.Owner;
import org.example.clinic.services.OwnerService;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/owners")
public class OwnerController {

    private final OwnerService ownerService;

    public OwnerController(OwnerService ownerService) {
        this.ownerService = ownerService;
    }

    @GetMapping
    public List<Owner> getAll() {
        return ownerService.getOwners();
    }

    public Owner getById(@RequestParam long id) {
        return ownerService.getById(id);
    }

    @PostMapping
    public Owner createOwner(@RequestBody Owner owner) {
        return ownerService.create(owner);
    }


    @PutMapping("/{id}")
    public Owner updateOwner(@PathVariable Long id, @RequestBody Owner owner) {
        owner.setId(id);
        return ownerService.update(owner);
    }


    @DeleteMapping("/{id}")
    public void deleteOwner(@PathVariable Long id) {
        ownerService.delete(id);
    }
}
