# marvelheroes.net

marvelheroes é um projeto de consulta a https://developer.marvel.com/docs

<h2>Demo</h2>

http://marvelheroes.wise2b.kinghost.net/

<h2>Requerimentos</h2>

<ul>
<li>.Net Framework 4.5 ou superior</li>
<li>Marvel API key</li>
</ul>

<h2>marvelheroes.net.common</h2>
<h4>Projeto que contem as funções do sistema</h4>
<h4>namespace marvelheroes.net.Common.Clients</h4>

<p>_privateKey => chave privada da Marvel API<p>
<p>_publicKey => chave publica da Marvel APIy<p>

<p>Namespace que encapsula os clients que fazem os requests segundo as necessidades</p>
<p>Exemplo:</p>
<p>IEnumerable<Character> FindCharacters(Dictionary<string, string> parameters)</p>
<p>retorna os characters(personagens) mediante os fitros informados</p>
 
<p>name - nome do personagem(deve ser o nome idêntico</p>
<p>nameStartsWith - nome do personagem pode conter apenas as inciais, ex: iron</p>
<p>limit - número de páginas que devem retonar</p>	
<p>offset - quantidade de itens por página</p>	

<p>IEnumerable<Character> FindCharacters(Dictionary<string, string> parameters)</p>
