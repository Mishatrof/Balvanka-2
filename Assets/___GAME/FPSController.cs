using UnityEngine;
using System.Collections;

public class FPSController : MonoBehaviour {

	[Header("Скорость перемещения")]
	[Range(1.0f,10.0f)]
	public float speedMove;

	[Header("Чувствительность мыши")]
	[Range(1.0f,25.0f)]
	public float sensivity;

	[Header("Сила прыжка")]
	[Range(1.0f,20.0f)]
	public float jump;

	[Header("Гравитация в воздухе")]
	[Range(1.0f,30.0f)]
	public float airGravity;

	[Header("Гравитация на земле")]
	[Range(1.0f,100.0f)]
	public float groundGravity;

	[Header("Ограничитель поворота")]
	public Vector2 clampAngle;

	//Кэш трансформа
	private Transform _transform;

	//Вектор вращения
	private Vector2 _angle;

	//Вектор направления движения
	private Vector3 _dir;

	//Мышь
	private float _mouseX;
	private float _mouseY;

	//Клавиши
	private float _vertical;
	private float _horizontal;

	//Компонент для перемещения
	private CharacterController _controller;
    
	private Animator Animator;

	//Компонент аудио
	private AudioSource _source;

	//Компонент джостика
	private MobileInput _input;

	//Компонент тача
	private TouchField _field;

	//Текущая гравитация
	private float _gravity;

	//Прыжок
	private bool _isJumping;

    public GameObject SecondWeapon;
    public GameObject MainWeapon;
    public GameObject axe;
    bool isPistol = false;
    public int Wood;

  

    public AudioClip pistl;
    public AudioClip axes;

    float firerate = 1f;
    float firetimer;
    private int Stone;
    private int Meat;

    void Start () {
		_controller = GetComponent<CharacterController> ();
	
		_source = GetComponent<AudioSource> ();
        Animator = axe.GetComponent<Animator>();
		_input = GameObject.Find ("MobileJoystick").GetComponent<MobileInput> ();
		_field = GameObject.Find ("TouchField").GetComponent<TouchField> ();

		_transform = transform;
	}
    public void TakemainWeapon()
    {
        MainWeapon.SetActive(true);
        SecondWeapon.SetActive(false);
        isPistol = false;
    }
    public void TakeSecondnWeapon()
    {
       
        
            MainWeapon.SetActive(false);
            SecondWeapon.SetActive(true);
            isPistol = true;
        
    }

    void Update () {

        if (firetimer < firerate)
            firetimer += Time.deltaTime;

		//Если игрок на земле
		if (_controller.isGrounded) {

			//Записываем значения нажатых клавиш
			_vertical = _input.Vertical();
			_horizontal = _input.Horizontal();

			//Текущая гравитация - земля
			_gravity = groundGravity;

			//Направление движения
			_dir = _transform.TransformDirection (_horizontal, 0.0f, _vertical);
			_dir *= speedMove;

			

			//Прыжок
			if (_isJumping==true) {
				_dir.y = jump;
			
				_isJumping = false;
			}

		} else {
			//Если не на земле тогда текущая гравитация - в воздухе
			_gravity = airGravity;
		}

		//Переещение персонажа
		_dir.y -= _gravity * Time.deltaTime;
		_controller.Move (_dir * Time.deltaTime);

	}


	void LateUpdate () {

		//Записываем значение мыши
		_mouseX = Input.GetAxis ("Mouse X");
		_mouseY = Input.GetAxis ("Mouse Y");

		_angle.x -= _field.TouchDist.y * sensivity*Time.deltaTime;
		_angle.y += _field.TouchDist.x * sensivity*Time.deltaTime;

		//Ограничение поворота
		_angle.x = Mathf.Clamp (_angle.x, -clampAngle.x, clampAngle.y);

		//Поворот
		Quaternion rot = Quaternion.Euler (_angle.x, _angle.y, 0.0f);
		_transform.rotation = rot;
	}
		
	//Включение прыжка
	public void Jumping(){
		if (_controller.isGrounded) {
			_isJumping = true;
		}
	}
    //Включение прыжка
    public void Attack()
    {
        if (_controller.isGrounded)
        {
            if (firerate > firetimer) return;
                
            if(isPistol == false)
            {
                int i = 3;
                i = Random.Range(0, 3);
                switch (i)
                {
                    case 0:
                        Animator.SetTrigger("IsAttack");
                        break;
                    case 1:
                        Animator.SetTrigger("IsAttack1");
                        break;
                    case 2:
                        Animator.SetTrigger("IsAttack2");
                        break;
                }
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit, 2f))
                {
                    if(hit.collider.tag == "Wood")
                    {
                        Wood++;
                        hit.collider.GetComponent<Health>().TakeDamage(15);
                    }
                    if (hit.collider.tag == "Stone")
                    {
                        Stone++;
                        hit.collider.GetComponent<Health>().TakeDamage(15);
                    }
                    if (hit.collider.tag == "Enemy")
                    {
                        Meat++;
                        hit.collider.GetComponent<Health>().TakeDamage(15);
                    }
                }
                _source.PlayOneShot(axes);
            }
            else
            {
                _source.PlayOneShot(pistl);
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 15f))
                {
                  
                    if (hit.collider.tag == "Enemy")
                    {
                        Meat++;
                        hit.collider.GetComponent<Health>().TakeDamage(35);
                    }
                }
            }

            firetimer = 0f;
        }
    }
}
