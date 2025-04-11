# 📱 Old Phone Pad Emulator

This project simulates the behavior of an old mobile phone keypad using a string of button presses as input. It translates keypress sequences into letters, 
handling editing features like backspace and space between words.

## 📂 Structure

This application was built following Clean Architecture principles, aiming to separate concerns clearly across layers and improve scalability and testability.

- `OldPhone.cs`: Main logic to process the input and convert it to letters.
- `OldPhoneUI.cs`: Entry point of the application and serves as the user-facing layer in the architecture.
- `OldPhoneTests.cs`: Test class with sample inputs and expected outputs.

## ✨ Features

- Input digits `2-9` to form letters by pressing multiple times (e.g., `2`, `22`, `222`).
- Use `0` to insert a **space**.
- Use `*` as a **backspace**:
  - If you're in the middle of a sequence (e.g., `666*`), it removes the last digit pressed (`666*` → `66`).
  - If no sequence is active, it deletes the last **letter** added to the output.
- Use ` ` (space character) to separate sequences.
- Use `#` to indicate the **end** of the input.

## 🔡 Example Inputs

| Input                         | Output         |
|------------------------------|----------------|
| `4433555 555666#`            | `HELLO`        |
| `227*#`                      | `B`            |
| `83377778#`                  | `TEST`         |
| `20220222`                   | `A B C`        |
| `44335666****555 555666069999999072555` | `HELLO MY PAL` |

## 📝 Notes on `*` behavior

The `*` character is context-sensitive:
- If you are currently typing a sequence (like `777`), it removes one digit from that sequence. Example:
  - Input: `777*` → `77`
  - Meaning: Instead of `R`, you now get `Q`
- If there is no active sequence, it removes the last letter that has already been added to the output.

This allows for precise control, similar to how users typed on actual old mobile phones.

## 🧪 Testing

The solution is covered with unit tests using `[TestCase]` attributes in NUnit. These include valid scenarios, backspace cases, and edge conditions.

<h2 align="center">🚀 Run it</h1>


