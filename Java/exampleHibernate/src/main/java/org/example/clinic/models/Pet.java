package org.example.clinic.models;

import jakarta.persistence.*;


@Entity
@Table(name = "pets")
public class Pet {


    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "pet_id")
    private Long id;


    @ManyToOne
    @JoinColumn(name = "owner_id", referencedColumnName = "owner_id")
    private Owner owner;


    @Column(name = "name")
    private String name;


    @Column(name = "animal_type")
    private String animalType;


    @Column(name = "breed")
    private String breed;


    @Column(name = "age")
    private Integer age;


    @Column(name = "vaccinations")
    private String vaccinations;


    public Long getId() {
        return id;
    }


    // Добавлены сеттеры
    public void setId(Long id) {
        this.id = id;
    }


    public void setOwner(Owner owner) {
        this.owner = owner;
    }


    public void setName(String name) {
        this.name = name;
    }


    public void setAnimalType(String animalType) {
        this.animalType = animalType;
    }


    public void setBreed(String breed) {
        this.breed = breed;
    }


    public void setAge(Integer age) {
        this.age = age;
    }


    public void setVaccinations(String vaccinations) {
        this.vaccinations = vaccinations;
    }


    public Owner getOwner() {
        return owner;
    }

    public String getName() {
        return name;
    }

    public String getAnimalType() {
        return animalType;
    }

    public String getBreed() {
        return breed;
    }

    public Integer getAge() {
        return age;
    }

    public String getVaccinations() {
        return vaccinations;
    }
}
