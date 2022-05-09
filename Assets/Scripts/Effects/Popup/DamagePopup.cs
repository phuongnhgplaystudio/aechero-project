using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    public static DamagePopup Create(Vector3 position, int damageAmount, float dir, bool isCriticalHit)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.Instance.pfDamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount, dir, isCriticalHit);
        return damagePopup;
    }

    private TextMeshPro textMesh;
    private float dir = 1; //-1 is left, 1 is right
    private float disappearCountdown;
    private Color textColor;

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    void Update()
    {
        float moveSpeed = 2f;
        float scaleSpeed = 20f;
        Vector3 direction = new Vector3(dir, 1f, 0);
        transform.position += direction * moveSpeed * Time.deltaTime;

        textMesh.fontSize += scaleSpeed / 4f * Time.deltaTime;

        disappearCountdown -= Time.deltaTime;
        if(disappearCountdown < 0)
        {
            textMesh.fontSize -= scaleSpeed * Time.deltaTime;

            float disappearSpeed = 5f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Setup(int damageAmount, float dir, bool isCriticalHit)
    {
        textMesh.SetText("-" + damageAmount.ToString());
        this.dir = dir;
        if (isCriticalHit) textMesh.color = new Color(255f / 255f, 117f / 255f, 117f / 255f, 1f);
        textColor = textMesh.color;
        disappearCountdown = .3f;
    }
}
