package ghjgsaj;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import org.hibernate.annotations.ColumnDefault;

@Entity
@Table(name = "clients")
public class Client {
    @Id
    @ColumnDefault("nextval('clients_id_seq')")
    @Column(name = "id", nullable = false)
    private Long id;

    @Column(name = "full_name", nullable = false, length = Integer.MAX_VALUE)
    private String fullName;

    @Column(name = "contact_phone", nullable = false, length = Integer.MAX_VALUE)
    private String contactPhone;

    @Column(name = "contact_mail_address", nullable = false, length = Integer.MAX_VALUE)
    private String contactMailAddress;

    @Column(name = "discount", nullable = false)
    private Integer discount;

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

    public Integer getDiscount() {
        return discount;
    }

    public void setDiscount(Integer discount) {
        this.discount = discount;
    }

}