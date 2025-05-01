package com.example.example_db;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class EditPhoneActivity extends AppCompatActivity {

    private Integer id;
    private EditText phoneEditText;
    private EditText nameEditText;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_edit_phone);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.editPhone), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });
        phoneEditText = findViewById(R.id.phoneEditText);
        nameEditText = findViewById(R.id.nameEditText);

        var phoneItem = (PhoneItem) getIntent().getSerializableExtra("phone_item");
        if (phoneItem != null) {
            id = phoneItem.getId();
            phoneEditText.setText(phoneItem.getPhone());
            nameEditText.setText(phoneItem.getName());
        }
    }

    public void onEditButtonClick(View view) {

        String nameData = nameEditText.getText().toString();
        String phoneData = phoneEditText.getText().toString();
        var updated_item = new PhoneItem(id, nameData, phoneData);

        Intent intent = new Intent(getApplicationContext(), MainActivity.class);
        intent.putExtra("updated_item", updated_item);
        setResult(55, intent);
        finish();
    }
}
