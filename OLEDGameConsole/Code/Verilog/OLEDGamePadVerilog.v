//-----------------------------------------------------
// Design Name : decoder_using_case
// File Name   : decoder_using_case.v
// Function    : decoder using case
// Coder       : Deepak Kumar Tala
//-----------------------------------------------------
module OLEDGamePadVerilog (
binary_in   , //  3 bit binary input
decoder_out , //  8-bit  out
decoder_out1 , //  8-bit  out
enable,        //  Enable for the decoder
read,
read1
);
input [2:0] binary_in  ;
input  enable ;
input read;
input read1;
output [7:0] decoder_out ;
output [7:0] decoder_out1 ;

reg [7:0] decoder_out ;
reg [7:0] decoder_out1;

always @ (enable or binary_in)
begin
  if (enable) begin
    case (binary_in)
      3'b000 : decoder_out <= 8'b0000000Z;
      3'b001 : decoder_out <= 8'b000000Z0;
      3'b010 : decoder_out <= 8'b00000Z00;
      3'b011 : decoder_out <= 8'b0000Z000;
      3'b100 : decoder_out <= 8'b000Z0000;
      3'b101 : decoder_out <= 8'b00Z00000;
      3'b110 : decoder_out <= 8'b0Z000000;
      3'b111 : decoder_out <= 8'bZ0000000;
    endcase
	 decoder_out1 = decoder_out;
  end
end

endmodule