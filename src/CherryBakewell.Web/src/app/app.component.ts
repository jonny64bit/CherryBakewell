import { Component } from '@angular/core';

enum Operator {
  Add = 0,
  Minus = 1,
  Multiply = 2,
  Divide = 3,
}

enum Stage {
  FirstNumber = 1,
  SecondNumber = 2
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  display = '0';
  currentNumber = 0;
  operatorEnum = Operator;
  stage = Stage.FirstNumber;

  inputA: null | number = null;
  inputB: null | number = null;
  operator: null | Operator = null;

  numberClick = (value: number) => {
    if (this.currentNumber == 0) this.currentNumber = value;
    else this.currentNumber = parseInt(this.currentNumber.toString() + value.toString());
    this.refreshDisplay();
  };

  operatorClick = (operator: Operator) => {
    if (this.stage == Stage.FirstNumber) {
      this.inputA = this.currentNumber;
      this.currentNumber = 0;
      this.refreshDisplay();
    }
    else if (this.inputB == null)
      this.inputB = this.currentNumber;

    this.stage = Stage.SecondNumber;
    this.operator = operator;
    this.equalsClick();
  }

  equalsClick = () => {
    if (this.inputA != null && this.operator != null && this.inputB == null && this.currentNumber > 0)
      this.inputB = this.currentNumber;

    if (this.operator == null || this.inputA == null || this.inputB == null) return;

    let newValue = 0;
    if (this.operator == Operator.Add)
      newValue = this.inputA + this.inputB;
    else if (this.operator == Operator.Divide)
      newValue = this.inputA / this.inputB;
    else if (this.operator == Operator.Multiply)
      newValue = this.inputA * this.inputB;
    else if (this.operator == Operator.Minus)
      newValue = this.inputA - this.inputB;

    this.recordValue(newValue);

    this.inputA = newValue;
    this.inputB = null;
    this.operator = null;
    this.currentNumber = newValue;
    this.refreshDisplay();
    this.stage = Stage.FirstNumber;
  }

  recordValue = async (newValue: number) => {
    await fetch("/api/data/add-calculation", {
      method: "POST",
      cache: "no-cache",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        inputA: this.inputA,
        inputB: this.inputB,
        operator: this.operator,
        answer: newValue
      }),
    });
  }

  clearClick = () => {
    this.inputA = null;
    this.inputB = null;
    this.operator = null;
    this.stage = Stage.FirstNumber;
    this.currentNumber = 0;
    this.refreshDisplay();
  }

  refreshDisplay = () => {
    this.display = this.currentNumber.toString();
  }
}