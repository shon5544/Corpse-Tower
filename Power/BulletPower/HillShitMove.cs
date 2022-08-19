using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HillShitMove : MonoBehaviour
{
    public GameObject HillText;
    public float hillPoint = 0.2f;

    Rigidbody2D rigid;

    Vector2 Dir;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(fuckinMove());
        Destroy(gameObject, 5f);
    }

    IEnumerator fuckinMove()
    {
        
        transform.DOMove(new Vector3(Random.Range(-7f, 7f), Random.Range(-7f, 7f), 0), 1f);
        yield return new WaitForSeconds(1f);
        //DOTween.To(() => transform.position, (pos) => transform.position = pos, GameObject.Find("Player").GetComponent<Transform>().position, 0.2f);
        while (true)
        {
            Dir = (GameObject.Find("Player").GetComponent<Transform>().position - transform.position);
            rigid.MovePosition(rigid.position + Dir.normalized * Time.deltaTime * 75f);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player.Life = hillPoint;
            var text = Instantiate(HillText, transform.position + new Vector3(0,0,-5), Quaternion.identity);
            text.GetComponent<TextMesh>().text = $"+{hillPoint}";
            Destroy(gameObject);
        }
    }


}
