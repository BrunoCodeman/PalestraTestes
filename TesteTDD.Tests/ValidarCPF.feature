#language: pt-br
Funcionalidade: ValidarCPF
				Eu, enquanto analista de crédito, preciso checar se um cliente está com o nome limpo antes de liberar um empréstimo. 
				Para tal, preciso inserir que o sistema me avise sobre a situação financeira do cliente ao digitar o CPF dele no cadastro

Cenário: Cliente com nome limpo
Dado um cliente com CPF "789.456.123-00"
Quando o CPF dele não estiver na lista do SPC ou Serasa
Então o sistema deve liberar a aprovação de crédito

Cenário: Cliente com nome sujo
Dado um cliente com CPF "123.456.789-00"
Quando o CPF dele estiver na lista do SPC ou Serasa
Então o sistema deve me avisar e impedir a aprovação de crédito
