package com.example.coffee.demo;

import jakarta.persistence.*;
import org.hibernate.annotations.ColumnDefault;

import java.util.LinkedHashSet;
import java.util.Set;

@Entity
@Table(name = "personnel")
public class Personnel {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @ColumnDefault("nextval('personnel_id_seq')")
    @Column(name = "id", nullable = false)
    private Long id;

    @Column(name = "full_name", nullable = false, length = Integer.MAX_VALUE)
    private String fullName;

    @Column(name = "contact_phone", nullable = false, length = Integer.MAX_VALUE)
    private String contactPhone;

    @Column(name = "contact_mail_address", nullable = false, length = Integer.MAX_VALUE)
    private String contactMailAddress;

    @Column(name = "\"position\"", nullable = false)
    private String position;

    @OneToMany(mappedBy = "personnel")
    private Set<PersonnelSchedule> personnelSchedules = new LinkedHashSet<>();

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getFullName() {
        return fullName;
    }

    public void setFullName(String fullName) {
        this.fullName = fullName;
    }

    public String getContactPhone() {
        return contactPhone;
    }

    public void setContactPhone(String contactPhone) {
        this.contactPhone = contactPhone;
    }

    public String getContactMailAddress() {
        return contactMailAddress;
    }

    public void setContactMailAddress(String contactMailAddress) {
        this.contactMailAddress = contactMailAddress;
    }

    public String getPosition() {
        return position;
    }

    public void setPosition(String position) {
        this.position = position;
    }

    public Set<PersonnelSchedule> getPersonnelSchedules() {
        return personnelSchedules;
    }

    public void setPersonnelSchedules(Set<PersonnelSchedule> personnelSchedules) {
        this.personnelSchedules = personnelSchedules;
    }

}