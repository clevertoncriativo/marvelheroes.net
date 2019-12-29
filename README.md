# marvelheroes.net

marvelheroes é um projeto de consulta a https://developer.marvel.com/docs

<h2>Demo</h2>

http://marvelheroes.wise2b.com.br/

<h2>Requerimentos</h2>

<ul>
<li>.Net Framework 4.5 ou superior</li>
<li>Marvel API key</li>
</ul>

<h2>marvelheroes.net.common</h2>
<h4>Solution que contem as funções do sistema</h4>
<h4>namespace marvelheroes.net.Common.Clients</h4>

<p>_privateKey => chave privada da Marvel API<p>
<p>_publicKey => chave publica da Marvel APIy<p>

<p>Namespace que encapsula os clients que fazem os requests segundo as necessidades</p>
<p>Método exemplo:</p>
<p><b>public IEnumerable<Character> FindCharacters(Dictionary<string, string> parameters)</b></p>
<p>retorna os characters(personagens) mediante os fitros informados</p>
 
<p><b>name</b> => nome do personagem(deve ser o nome idêntico</p>
<p><b>nameStartsWith</b> => nome do personagem pode conter apenas as inciais, ex: iron</p>
<p><b>limit</b> => número de páginas que devem retonar</p>	
<p><b>offset</b> => quantidade de itens por página</p>	


