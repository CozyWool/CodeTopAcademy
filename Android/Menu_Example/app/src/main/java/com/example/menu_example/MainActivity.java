package com.example.menu_example;

import android.content.Intent;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
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

        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);


    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater menuInflater = getMenuInflater();
        menuInflater.inflate(R.menu.main, menu);


        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        var itemId = item.getItemId();


        if (itemId == R.id.settings) {
            Toast.makeText(this, "This is settings", Toast.LENGTH_SHORT).show();
            Intent intent = new Intent(this, SettingsActivity.class);
            startActivityForResult(intent, 0);
        }
        if (itemId == R.id.open) {
            Toast.makeText(this, "This is open", Toast.LENGTH_SHORT).show();
        }
        if (itemId == R.id.save) {
            Toast.makeText(this, "This is save", Toast.LENGTH_SHORT).show();
        }
        if (itemId == R.id.close) {
            Toast.makeText(this, "Finish app", Toast.LENGTH_SHORT).show();
            finishAffinity();
        }
        if (itemId == R.id.submenu4 || itemId == R.id.submenu5 || itemId == R.id.submenu6) {
            item.setChecked(!item.isChecked());
        }

        return super.onOptionsItemSelected(item);
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);

        var preferences = PreferenceManager.getDefaultSharedPreferences(this);
        var wifiStatus = preferences.getBoolean("wifi", false);
        var hintStatus = preferences.getBoolean("hint", false);

        Log.d("WifiStatus", String.valueOf(wifiStatus));
        Log.d("HintStatus", String.valueOf(hintStatus));
    }
}