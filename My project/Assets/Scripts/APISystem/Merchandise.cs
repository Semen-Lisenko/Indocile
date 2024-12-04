using UnityEngine;

public class Merchandise : MonoBehaviour
{
    public Product Product;
    public Animator Animator;
    public void OnMouseEnter()
    {
        Animator.SetBool("IsSelected", true);
    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            ShopControl.ShopCart[Product.id]++;
        }
        else if (Input.GetMouseButton(1) && ShopControl.ShopCart[Product.id] - 1 > 0)
        {
            ShopControl.ShopCart[Product.id]--;
        }
    }
    public void OnMouseExit()
    {
        Animator.SetBool("IsSelected", false);
    }
    public void OnDisable()
    {
        Animator.SetBool("IsSelected", false);
    }
}
