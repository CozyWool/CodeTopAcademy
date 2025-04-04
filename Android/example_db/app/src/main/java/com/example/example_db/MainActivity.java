package com.example.example_db;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import java.util.List;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_main);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });

        TextView textView;
        List<PhoneModel> contacts;

        DatabaseManager databaseManager = new DatabaseManager(this, "phonesDb.db", null, 1);


        contacts = databaseManager.select();

        StringBuilder sb = new StringBuilder();

        TableLayout tableLayout = new TableLayout(this);
        tableLayout.setLayoutParams(new TableLayout.LayoutParams(TableLayout.LayoutParams.MATCH_PARENT, TableLayout.LayoutParams.WRAP_CONTENT));
        if (!contacts.isEmpty()) {
            for (PhoneModel model : contacts) {
                TableRow tableRow = new TableRow(this);

                TextView textViewId = new TextView(this);
                textViewId.setText(String.format("Id: %s\n", model.getId()));
                TextView textViewName = new TextView(this);
                textViewName.setText(String.format("Name: %s\n", model.getName()));
                TextView textViewPhone = new TextView(this);
                textViewPhone.setText(String.format("Phone: %s\n", model.getPhone()));
                Button deleteButton = new Button(this);
                deleteButton.setText("Удалить");
                deleteButton.setOnClickListener(view -> {
                    databaseManager.delete(model.getId());
                    Intent intent = new Intent(getApplicationContext(), MainActivity.class);
                    startActivity(intent);
                });

                tableRow.addView(textViewId, new TableRow.LayoutParams(
                        TableRow.LayoutParams.MATCH_PARENT, TableRow.LayoutParams.WRAP_CONTENT, 0.5f));
                tableRow.addView(textViewName, new TableRow.LayoutParams(
                        TableRow.LayoutParams.MATCH_PARENT, TableRow.LayoutParams.WRAP_CONTENT, 0.5f));
                tableRow.addView(textViewPhone, new TableRow.LayoutParams(
                        TableRow.LayoutParams.MATCH_PARENT, TableRow.LayoutParams.WRAP_CONTENT, 0.5f));
                tableRow.addView(deleteButton, new TableRow.LayoutParams(
                        TableRow.LayoutParams.MATCH_PARENT, TableRow.LayoutParams.WRAP_CONTENT, 0.5f));

                tableLayout.addView(tableRow);
            }
        }

        var addNewPhoneButton = findViewById(R.id.addNewPhoneButton);
        addNewPhoneButton.setOnClickListener(view -> {
            Intent intent = new Intent(getApplicationContext(), AddNewPhoneActivity.class);
            startActivity(intent);
        });
        ConstraintLayout layout = findViewById(R.id.main);
        layout.addView(tableLayout);
    }
}