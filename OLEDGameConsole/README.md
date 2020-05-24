# OLED Game Console
OLED Game console for ECE project

1. [Arduino Code](Code/Menu)
2. [Verilog Code](Code/Verilog)
3. [PCB Files](PCB)

PCBs are designed with PADs, if you cannot open it, a PDF file is included. The circuit consists of an 74HC138.

To read a button input:

Before reading from the GPIO input, control 74HC138 to select the corresponding pin the button is connected. If there's a LOW voltage recorded, that means there's an input at that corresponding pin.

For example, if you want to read the A button (in my circuit it would be the 7th button, or 111th button)
Since all the buttons are connected to pin 7, read pin 7 after an output of 111. If an expected state is recorded, it means that specific button is pressed.

You can read all the buttons at the same time by quickly scanning them.

Not sure if this method affects the sensitivity or has neglectable impact on the sensitivity since:
1. Buttons are rarely pressed together
2. Arduino responds faster than my brain, which is only equipped with single core processor running at 0.5 Hz.

Arduino Micro has very limited space to store multiple applications, the two apps currently available are
1. SpaceTrash game(from the u8g2 example)
2. Calculator (Standalone versions [here](https://github.com/RustColeone/U8g2Calculator))
3. PONG Game
4. Still testing, Tetris

A programmable logic MAX7000 is used in the later versions of the circuit board, also, in order to add more games, the Pro Micro was replaced with SAMD21. The SAMD21 mini breakout from Sparkfun provided an easy way to upgrade the processor.

However the Sparkfun's SAMD21 does have a bit of difference with the Pro Micro, such as a pin is reset instead of ground, and some pin numbers are different.

If I insisted on using the Pro Micro, I might have to use Atmel ICE to upload the code bypassing the bootloader which could free up more space for me.

A possible way to solve this issue will be to edit and remove unnecessary components from the libraries that we used
