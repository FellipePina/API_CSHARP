const API_URL = "/api/funcionarios";

function listarFuncionarios() {
    fetch(API_URL)
        .then(res => res.json())
        .then(data => {
            const tbody = document.querySelector("#tabelaFuncionarios tbody");
            tbody.innerHTML = ""; // Limpa antes de preencher

            data.forEach(func => {
                const row = `
                    <tr>
                        <td>${func.id}</td>
                        <td>${func.nome}</td>
                        <td>${func.idade}</td>
                        <td>${func.sexo}</td>
                        <td>${func.cpf}</td>
                        <td>${func.email}</td>
                        <td>${func.celular}</td>
                        <td>${func.cargo}</td>
                        <td>${func.setor}</td>
                        <td>${func.cargaHorariaSemanal}</td>
                        <td>${func.salario.toFixed(2)}</td>
                        <td>${func.estadoCivil}</td>
                        <td>${func.gastosPorMes.toFixed(2)}</td>
                    </tr>
                `;
                tbody.innerHTML += row;
            });
        })
        .catch(err => {
            const tbody = document.querySelector("#tabelaFuncionarios tbody");
            tbody.innerHTML = `<tr><td colspan="13">Erro ao carregar dados: ${err.message}</td></tr>`;
        });
}

function buscarFuncionarioPorId() {
    const id = document.getElementById("idBusca").value;
    if (!id) return alert("Informe um ID válido.");

    fetch(`${API_URL}/${id}`)
        .then(res => {
            if (!res.ok) throw new Error("Funcionário não encontrado");
            return res.json();
        })
        .then(func => {
            const tbody = document.querySelector("#tabelaBuscaPorId tbody");
            tbody.innerHTML = `
                <tr>
                    <td>${func.id}</td>
                    <td>${func.nome}</td>
                    <td>${func.idade}</td>
                    <td>${func.sexo}</td>
                    <td>${func.cpf}</td>
                    <td>${func.email}</td>
                    <td>${func.celular}</td>
                    <td>${func.cargo}</td>
                    <td>${func.setor}</td>
                    <td>${func.cargaHorariaSemanal}</td>
                    <td>${func.salario.toFixed(2)}</td>
                    <td>${func.estadoCivil}</td>
                    <td>${func.gastosPorMes.toFixed(2)}</td>
                </tr>
            `;
        })
        .catch(err => {
            const tbody = document.querySelector("#tabelaBuscaPorId tbody");
            tbody.innerHTML = `<tr><td colspan="13">${err.message}</td></tr>`;
        });
}

document.getElementById("formCadastro").addEventListener("submit", function (e) {
    e.preventDefault();

    const funcionario = {
        nome: document.getElementById("nome").value,
        idade: parseInt(document.getElementById("idade").value),
        sexo: document.getElementById("sexo").value,
        cpf: document.getElementById("cpf").value,
        email: document.getElementById("email").value,
        celular: document.getElementById("celular").value,
        cargo: document.getElementById("cargo").value,
        setor: document.getElementById("setor").value,
        cargaHorariaSemanal: parseInt(document.getElementById("cargaHoraria").value),
        salario: parseFloat(document.getElementById("salario").value),
        estadoCivil: document.getElementById("estadoCivil").value,
        gastosPorMes: parseFloat(document.getElementById("gastos").value)
    };

    fetch(API_URL, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(funcionario)
    })
    .then(res => {
        if (!res.ok) throw new Error("Erro ao cadastrar");
        return res.json();
    })
    .then(data => {
        // Monta uma tabela com os dados do funcionário cadastrado
        const resultado = document.getElementById("resultadoCadastro");
        resultado.innerHTML = `
            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Nome</th>
                        <th>Idade</th>
                        <th>Sexo</th>
                        <th>CPF</th>
                        <th>Email</th>
                        <th>Celular</th>
                        <th>Cargo</th>
                        <th>Setor</th>
                        <th>Carga Horária</th>
                        <th>Salário</th>
                        <th>Estado Civil</th>
                        <th>Gastos/mês</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>${data.id}</td>
                        <td>${data.nome}</td>
                        <td>${data.idade}</td>
                        <td>${data.sexo}</td>
                        <td>${data.cpf}</td>
                        <td>${data.email}</td>
                        <td>${data.celular}</td>
                        <td>${data.cargo}</td>
                        <td>${data.setor}</td>
                        <td>${data.cargaHorariaSemanal}</td>
                        <td>${data.salario.toFixed(2)}</td>
                        <td>${data.estadoCivil}</td>
                        <td>${data.gastosPorMes.toFixed(2)}</td>
                    </tr>
                </tbody>
            </table>
            <p style="color:green; font-weight:bold; margin-top: 8px;">Cadastrado com sucesso!</p>
        `;

        document.getElementById("formCadastro").reset();
    })
    .catch(err => {
        document.getElementById("resultadoCadastro").textContent = err.message;
    });
});

function deletarFuncionario() {
    const id = document.getElementById("deletarId").value;
    if (!id) return;

    fetch(`${API_URL}/${id}`, { method: "DELETE" })
        .then(res => {
            if (res.ok) {
                document.getElementById("resultadoDelete").textContent = "Funcionário deletado com sucesso.";
            } else {
                document.getElementById("resultadoDelete").textContent = "Funcionário não encontrado.";
            }
        })
        .catch(err => {
            document.getElementById("resultadoDelete").textContent = err.message;
        });
}