package com.demo.coffeeshop.models;

import java.util.HashSet;
import java.util.Set;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Table;
import jakarta.persistence.Id;
import jakarta.persistence.OneToMany;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;

import java.sql.Date;

@Entity
@Table(name = "clients")
public class Clients implements java.io.Serializable {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id")
    private Long id;

    @Column(name = "full_name")
    private String fullName;

    @Column(name = "contact_phone")
    private String contactPhone;

    @Column(name = "contact_mail_address")
    private String contactMailAddress;

    @Column(name = "discount")
    private int discount;

    @Column(name = "birth_date")
    private Date birthDate;

    @OneToMany(mappedBy = "clients")
    private Set<Orders> orderses = new HashSet<>();

    public Clients() {}

    public Clients(long id, String fullName, String contactPhone, String contactMailAddress, int discount, Date birthDate) {
        this.id = id;
        this.fullName = fullName;
        this.contactPhone = contactPhone;
        this.contactMailAddress = contactMailAddress;
        this.discount = discount;
        this.birthDate = birthDate;
    }

    public Clients(long id, String fullName, String contactPhone, String contactMailAddress, int discount, Set orderses, Date birthDate) {
        this.id = id;
        this.fullName = fullName;
        this.contactPhone = contactPhone;
        this.contactMailAddress = contactMailAddress;
        this.discount = discount;
        this.orderses = orderses;
        this.birthDate = birthDate;
    }

    public long getId() {
        return this.id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getFullName() {
        return this.fullName;
    }

    public void setFullName(String fullName) {
        this.fullName = fullName;
    }

    public String getContactPhone() {
        return this.contactPhone;
    }

    public void setContactPhone(String contactPhone) {
        this.contactPhone = contactPhone;
    }

    public String getContactMailAddress() {
        return this.contactMailAddress;
    }

    public void setContactMailAddress(String contactMailAddress) {
        this.contactMailAddress = contactMailAddress;
    }

    public int getDiscount() {
        return this.discount;
    }

    public void setDiscount(int discount) {
        this.discount = discount;
    }

    public Set getOrderses() {
        return this.orderses;
    }

    public void setOrderses(Set orderses) {
        this.orderses = orderses;
    }

    public Date getBirthDate() {
        return this.birthDate;
    }

    public void setBirthDate(Date birthDate) {
        this.birthDate = birthDate;
    }

    @Override
    public String toString() {
        return "Клиент:" + fullName + " (Скидка:" + discount + "%)";
    }
}