package com.example.viewsswitchexample;

import java.io.Serializable;

public class KeyItem implements Serializable {
    private String key;
    private String description;

    public KeyItem(String key, String description) {
        this.key = key;
        this.description = description;
    }

    public String getKey() {
        return key;
    }

    public void setKey(String key) {
        this.key = key;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }
}
