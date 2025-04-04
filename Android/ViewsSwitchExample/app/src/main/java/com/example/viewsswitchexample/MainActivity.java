package com.example.viewsswitchexample;

import android.content.Intent;
import android.os.Bundle;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

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

        var aboutButton = findViewById(R.id.linkAboutButton);
        aboutButton.setOnClickListener(view -> {
            Intent intent = new Intent(getApplicationContext(), AboutActivity.class);
            startActivity(intent);
        });

        var inputDataButton = findViewById(R.id.inputDataButton);
        inputDataButton.setOnClickListener(view -> {
            Intent intent = new Intent(getApplicationContext(), InputDataActivity.class);
            startActivity(intent);
        });

        var inputData2Button = findViewById(R.id.inputData2Button);
        inputData2Button.setOnClickListener(view -> {
            Intent intent = new Intent(getApplicationContext(), SecondActivity.class);
            startActivityForResult(intent, 42);
        });
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        if (requestCode == 42) {
            if (resultCode == RESULT_OK) {
                var dataValue = data.getStringExtra("data");
                Toast.makeText(this, dataValue, Toast.LENGTH_SHORT).show();
            } else {
                Toast.makeText(this, "Request cancelled", Toast.LENGTH_SHORT).show();
            }
        }
    }
}