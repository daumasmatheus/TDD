Funcionalidade: Bank Operations
	Como um usuario de operacoes bancarias
	Sendo um cliente e possuindo uma conta
	Gostaria de efetuar operações de saque e deposito
	
Esquema do Cenário: Saque
	Dado uma conta com o seguninte saldo <saldoInicial>
	Quando efetuo um saque de valor <valorSaque>
	Então deverei ter um saldo final de <saldoFinal>
	Exemplos: 
	| saldoInicial | valorSaque | saldoFinal |
	| 100		   | 50         | 50         |
	| 50           | 50         | 0          |
	| 0            | 50         | -50        |

Esquema do Cenário: Deposito
	Dado uma conta com o seguinte saldo <saldoInicial>
	Quando efetuo um  deposito de valor <valorDeposito>
	Entao deverei ter um saldo final de <saldoFinal>
	Exemplos: 
	| saldoInicial | valorDeposito | saldoFinal |
	| 0            | 50       | 50         |
	| 50           | 50       | 100        |
	| 100          | 20       | 120        |