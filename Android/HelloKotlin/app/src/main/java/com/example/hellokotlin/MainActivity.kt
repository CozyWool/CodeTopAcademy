package com.example.hellokotlin

import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {
    //    private var counter = 0;
    private lateinit var inputField: EditText
    private lateinit var resultField: TextView
    private lateinit var operationField: TextView
    private var firstValue = 0.0
    private var secondValue = 0.0
    private var currentOperation = ""


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
        resultField = findViewById(R.id.resultField)
        operationField = findViewById(R.id.operationField)
    }

    fun onNumberClick(view: View) {
        val number = (view as Button).text.toString()
        inputField.setText(inputField.text.toString() + number)
    }

    fun onOperationClick(view: View) {
        val operation = (view as Button).text.toString()

        firstValue = inputField.text.toString().toDouble()
        currentOperation = operation

        resultField.setText(firstValue.toString())
        inputField.setText("")
        operationField.setText(operation)
    }

    fun onEqualsClick(view: View) {
        secondValue = inputField.text.toString().toDouble();

        var result = firstValue
        when (currentOperation) {
            "+" -> result += secondValue
            "-" -> result -= secondValue
            "/" -> result /= secondValue
            "*" -> result *= secondValue
        }
        resultField.setText(result.toString())
        inputField.setText("")
        operationField.text = ""
    }
//    fun onClick(view: View) {
//        val textView = findViewById<TextView>(R.id.textView);
//        textView.text = (++counter).toString();
//    }
}