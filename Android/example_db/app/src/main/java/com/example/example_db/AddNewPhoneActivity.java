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

public class AddNewPhoneActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_add_new_phone);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.addNewPhone), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });


    }

    public void onAddButtonClick(View view) {
        EditText phone = findViewById(R.id.phoneEditText);
        EditText name = findViewById(R.id.nameEditText);

        String nameData = name.getText().toString();
        String phoneData = phone.getText().toString();

        DatabaseManager databaseManager = new DatabaseManager(this, "phonesDb.db", null, 1);
        databaseManager.add(nameData, phoneData);


        Intent intent = new Intent(getApplicationContext(), MainActivity.class);
        startActivity(intent);
    }
}
