using System.Collections;
using Cinemachine;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    Player player;

    private SpriteRenderer sr;
    [Header("Screen Shake Fx")]
    private CinemachineImpulseSource screenShake;
    [SerializeField] private Vector3 shakePower;


    [Header("Flash FX")]
    [SerializeField] private Material hitMaterial;
    private Material originalMaterial;

    //????    
    [Header("Hit FX")]
    [SerializeField] private GameObject hitFXPrefab;
    [SerializeField] private GameObject criticalHitFXPrefab;



    private void Start()
    {
        player = PlayerManager.instance.player;
        screenShake = GetComponent<CinemachineImpulseSource>();
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMaterial = sr.material;
    }
    //????
    public void ScreenShake(Vector3 _shakePower)
    {
        shakePower = _shakePower;
        screenShake.m_DefaultVelocity = new Vector3(0,0,0);
        screenShake.GenerateImpulse();
        screenShake.m_DefaultVelocity = new Vector3(shakePower.x * player.facingDir, shakePower.y);
        screenShake.GenerateImpulse();
    }

    
    private IEnumerator FlashFX()
    {
        sr.material = hitMaterial;
        yield return new WaitForSeconds(0.15f);
        sr.material = originalMaterial;
    }

    //????
    public void HitFX(Transform _hitTarget)
    {
        GameObject hitFX = Instantiate(hitFXPrefab, _hitTarget.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
        hitFX.transform.Rotate(0, 0, Random.Range(0, 360));
        Destroy(hitFX, 0.5f);
    }
    public void CriticalHitFX(Transform _hitTarget)
    {
        GameObject criticalHitFX = Instantiate(criticalHitFXPrefab, _hitTarget.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
        criticalHitFX.transform.Rotate(0, 0, Random.Range(0, 360));
        Destroy(criticalHitFX, 0.5f);
    }
}
