package com.example.example_db;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.widget.Button;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;

import androidx.activity.EdgeToEdge;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class MainActivity extends AppCompatActivity {

    private DatabaseManager databaseManager;

    @SuppressLint("ResourceType")
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

        databaseManager = new DatabaseManager(this, "phonesDb.db", null, 1);

        updateTable();

        var addNewPhoneButton = findViewById(R.id.addNewPhoneButton);
        addNewPhoneButton.setOnClickListener(view -> {
            Intent intent = new Intent(getApplicationContext(), AddNewPhoneActivity.class);
            startActivityForResult(intent, 50);
        });
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        if (requestCode == 50 && resultCode == 51) {
            var item = (PhoneItem) data.getSerializableExtra("newItem");

            databaseManager.add(item.getName(), item.getPhone());
            updateTable();
        }
        if (requestCode == 54 && resultCode == 55) {
            var item = (PhoneItem) data.getSerializableExtra("updated_item");
            if (item != null) {
                databaseManager.update(item);
                updateTable();
            }
        }
    }

    private void updateTable() {
        var contacts = databaseManager.select();

        var tableLayout = (TableLayout) findViewById(R.id.tableLayout);
        tableLayout.removeViews(1, tableLayout.getChildCount() - 1);
        if (!contacts.isEmpty()) {
            for (PhoneItem item : contacts) {
                TableRow tableRow = new TableRow(this);

                TextView textViewId = new TextView(this);
                textViewId.setText(String.format("%s\n", item.getId()));
                TextView textViewName = new TextView(this);
                textViewName.setText(String.format("%s\n", item.getName()));
                TextView textViewPhone = new TextView(this);
                textViewPhone.setText(String.format("%s\n", item.getPhone()));
                Button deleteButton = new Button(this);
                deleteButton.setText("Delete");
                deleteButton.setOnClickListener(view -> {
                    databaseManager.delete(item.getId());
                    updateTable();
                });
                
                

                Button updateButton = new Button(this);
                updateButton.setText("Edit");
                updateButton.setOnClickListener(view -> {
                    Intent intent = new Intent(getApplicationContext(), EditPhoneActivity.class);
                    intent.putExtra("phone_item", item);
                    startActivityForResult(intent, 54);
                });

                
                tableRow.addView(textViewId, new TableRow.LayoutParams(
                        TableRow.LayoutParams.MATCH_PARENT, TableRow.LayoutParams.WRAP_CONTENT, 0.5f));
                tableRow.addView(textViewName, new TableRow.LayoutParams(
                        TableRow.LayoutParams.MATCH_PARENT, TableRow.LayoutParams.WRAP_CONTENT, 0.5f));
                tableRow.addView(textViewPhone, new TableRow.LayoutParams(
                        TableRow.LayoutParams.MATCH_PARENT, TableRow.LayoutParams.WRAP_CONTENT, 0.5f));
                tableRow.addView(deleteButton, new TableRow.LayoutParams(
                        TableRow.LayoutParams.MATCH_PARENT, TableRow.LayoutParams.WRAP_CONTENT, 0.5f));
                tableRow.addView(updateButton, new TableRow.LayoutParams(
                        TableRow.LayoutParams.MATCH_PARENT, TableRow.LayoutParams.WRAP_CONTENT, 0.5f));

                tableLayout.addView(tableRow);
            }
        }
    }

}