using UnityEngine;
using UnityEngine.UI;

public class MsjCuadrodearte : MonoBehaviour
{
    public string MsjNumero;
    public string MsjAño;
    public string MsjPremio;
    public string MsjAutor;
    public string MsjNombreObra;

    Text texto;
    void Start()
    {

        texto = GameObject.FindGameObjectWithTag("TextoDescripcion").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

     void OnMouseEnter() {
        texto.text = MsjNumero + " - " + MsjAño + " - " + MsjPremio + " - " + MsjAutor+ " - " + MsjNombreObra;
    }

    
     void OnMouseExit() {
        texto.text = "";
    }
}
