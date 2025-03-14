package com.demo.coffeeshop.models;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Table;
import jakarta.persistence.Id;
import jakarta.persistence.OneToMany;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;

import java.util.HashSet;
import java.util.Set;

@Entity
@Table(name = "cafe_assortment")
public class CafeAssortment implements java.io.Serializable {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "id")
	private Long id;

	@Column(name = "type")
	private String type;

	@Column(name = "price")
	private int price;

	@Column(name = "name")
	private String name;

	@OneToMany(mappedBy = "cafeAssortment")
	private Set<Orders> orderses = new HashSet<>();

	public CafeAssortment() {}

	public CafeAssortment(long id, String type, int price, String name) {
		this.id = id;
		this.type = type;
		this.price = price;
		this.name = name;
	}

	public CafeAssortment(long id, String type, int price, String name, Set orderses) {
		this.id = id;
		this.type = type;
		this.price = price;
		this.name = name;
		this.orderses = orderses;
	}

	public long getId() {
		return this.id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public String getType() {
		return this.type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public int getPrice() {
		return this.price;
	}

	public void setPrice(int price) {
		this.price = price;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public Set getOrderses() {
		return this.orderses;
	}

	public void setOrderses(Set orderses) {
		this.orderses = orderses;
	}
}