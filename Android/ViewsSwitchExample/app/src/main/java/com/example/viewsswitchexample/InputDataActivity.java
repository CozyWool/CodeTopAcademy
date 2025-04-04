package com.example.viewsswitchexample;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

public class InputDataActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        EdgeToEdge.enable(this);
        setContentView(R.layout.activity_data);
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.input_data), (v, insets) -> {
            Insets systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars());
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom);
            return insets;
        });


    }

    public void onTransferButtonClick(View view) {
        EditText key = findViewById(R.id.key);
        EditText description = findViewById(R.id.description);

        String keyData = key.getText().toString();
        String descriptionData = description.getText().toString();
        KeyItem keyItem = new KeyItem(keyData, descriptionData);


        Intent intent = new Intent(getApplicationContext(), AboutActivity.class);
        intent.putExtra("user_input_key_item", keyItem);
        startActivity(intent);
    }
}