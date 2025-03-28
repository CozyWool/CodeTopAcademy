package com.example.androidpracticeone

import android.os.Bundle
import android.view.View
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {
    private lateinit var inputField: EditText

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }
        inputField = findViewById(R.id.inputField)
    }

    fun onSubmitButtonClick(view: View) {
        if (inputField.text.isEmpty()) {
            Toast.makeText(this, "Введите ваше имя в поле ввода", Toast.LENGTH_LONG).show()
        } else {
            Toast.makeText(this, "Привет, ${inputField.text}!", Toast.LENGTH_LONG).show()
        }
    }
}