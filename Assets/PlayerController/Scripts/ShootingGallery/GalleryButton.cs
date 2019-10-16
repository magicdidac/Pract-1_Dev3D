using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalleryButton : InteractableObject
{

    [SerializeField] public bool canInteract = true;
    [SerializeField] private ShootingGallery gallery = null;

    public override bool CanInteractIt()
    {
        return canInteract;
    }

    public override void Interact()
    {
        canInteract = false;
        gallery.GalleryStart();
    }
}
