Funcionalidade: Operacoes banco
	Visto que sou um cliente de banco e possuo uma conta
	Como usuario de operacoes bancarias
	Gostaria de efetuar operacoes de saque e deposito

Contexto: 
	Dado conta valida

Esquema do Cenário: Saque
	E com o saldo inicial de <saldoInicial>
	Quando efetuo um saque de <valorSaque>
	Então o meu saldo final devera ser de <saldoFinal>
Exemplos: 
	| saldoInicial | valorSaque | saldoFinal |
	| 0            | 50         | -50        |
	| 100          | 20         | 80         |
	| 80           | 50         | 30         |

Esquema do Cenario: Deposito
	E com saldo inicial de <saldoInicial>
	Quando efetuo um deposito de <valorDeposito>
	Entao o meu saldo final apos o deposito devera ser de <saldoFinal>
Exemplos: 
	| saldoInicial | valorDeposito | saldoFinal |
	| 0            | 100           | 100        |
	| 50           | 200           | 250        |
	| 200          | 80            | 280        |