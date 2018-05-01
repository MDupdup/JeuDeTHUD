﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class NewAvatarImage : MonoBehaviour {

	public void RegisterSelectedImage()
    {
        SelectAvatarMenu.tempNewPlayer.Base64Image = PPSerialization.ImageToBase64(GetComponent<AvatarItem>().avatarImage.sprite.texture);
    }
}