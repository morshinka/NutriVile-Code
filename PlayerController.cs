using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // note: perbedaan antara private dan public
    // public dapat di akses dari luar class contoh public index maka dapat digunakan seperti ini void start() {var1 = index.value;}
    // private hanya dapat di akses dari dalam class contoh, private controller; lalu masuk kedalam function void update() {controller.value}

    //1. menggunakan private karena untuk menentukan aksesibilitas. selanjutnya ambil CharacterController dari componen yang sudah di tambahkan di unity lalu buat variable yang nantinya akan digunakan.
    private CharacterController controller;
    // 3. masih menggunakan private untuk menentukan aksesibilitas gunakan komponen Animator yang sudah di tambahkan pada unity lalu membuat variable yang nantinya akan digunakan. 
    private Animator animator;

    [Header("Movement System")]

    // 7. membuat method walkSpeed, runSpeed dan moveSpeed untuk menentukan kecepatan
    public float walkSpeed = 4f;
    public float runSpeed = 8f;
    private float moveSpeed = 4f;

    PlayerInteraction playerInteraction;


    // Start is called before the first frame update
    void Start()
    {
        // 2. isi nilai dari controller dengan mengambil componen menggunakan GetComponent lalu componen mana yang akan digunakan, karena ini akan mengontroll character maka menggunakan CharacterController
        controller = GetComponent<CharacterController>();

        // 4. isi nilai dari animator dengan mengambil componen menggunakan GetComponent lalu componen mana yang akan digunakan, karena ini akan mengontroll animasi saat charater digerakan maka menggunakan Animator
        animator = GetComponent<Animator>();

        playerInteraction = GetComponentInChildren<PlayerInteraction>();
    }

    // Update is called once per frame
    void Update()
    {
        //
        Move();

        Interact();
    }

    public void Interact()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            playerInteraction.Interact();
        }
    }

    // membuat function Move untuk menggerakkan karakter
    public void Move()
    {
        // 5. membuat variabel horizontal dan vertical untuk menampung input dari keyboard. menggunakan float karena input yang didapat bernilai ganjil selanjutnya membuat variable yang nantinya akan digunakan seperti horizontal dan vertical lalu isikan nilai dari variable tersebut dengan Input lalu pilih antara GetAxis dan GetAxisRaw karena kedua componen ini hampir sama hanya yang membedakan antara GetAxisRaw adalah nilai yang didapat tidak akan berubah sedangkan GetAxis adalah nilai yang didapat akan berubah selanjutnya menggunakan komponen pada unity Horizontal dan Vertical untuk penulisanya harus sama persis dengan yang ada di unity 
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // 6. gunakan Vector3 lalu isikan nilai dari variable horizontal dan vertical dan tambahkan normalized
        // 6.1. Vector3 digunakan untuk menentukan sumbu X, Y, dan Z. sedangkan Vector2 digunakan untuk menentukan sumbu X dan Y
        // 6.2. tambahkan sumbu X diambil dari variable horizontal, Y setting 0f menyesuaikan pada penjelasana nomor 5 karena menggunakan float, dan Z menggunakan variable vertical
        // 6.3. gunakan operator . untuk memanggil method normalizred yang digunakan untuk memberikan sebuah nilai 0-1
        Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;

        // 8. gunakan Vector3 untuk implementasi gerakan 3D lalu buat variable velocity lalu tambahkan moveSpeed yang akan dikalulasi dengan Time.deltaTime dan dir yang menentukan arah gerakan
        // 8.1. Time.deltaTime digunakan untuk menentukan kecepatan gerakan dan dapat digunakan untuk menghindari kecepatan yang cepat atau lambat pada karakter
        Vector3 velocity = moveSpeed * Time.deltaTime * dir;

        // 9. setelah menambahkan Sprint pada project unity maka dilakukan penyesuaian gunakan if yang bernilai true dan else nilai false. 
        // 9.1. penggunaan IF Input.Getbutton("Sprint) maka jadikan nilai moveSpeed menjadi runSpeed lalu gunakan var animator untuk mengakses componen Animator.setBool dengan nama yang digunakan pada animatornya isikan value true
        // 9.2. penggunaan ELSE moveSpeed menjadi walkSpeed lalu gunakan var animator untuk mengakses componen Animator.setBool dengan nama yang digunakan pada animatornya isikan value false
        if(Input.GetButton("Sprint"))
        {
            moveSpeed = runSpeed;
            animator.SetBool("Running", true);
        }else
        {
            moveSpeed = walkSpeed;
            animator.SetBool("Running", false);
        }

        // 10. membuat kondisi jika nilai dir yang akan dihitung menggunakan componen magnitude yang bernilai >= 0.1f atau jika nilai dir lebih besar atau sama dengan 0.1f maka nilai true
        if(dir.magnitude >= 0.1f)
        {
            // 10.1 digunakan untuk mempermudah mengatur rotasi object(karakter) yang bergerak berdasarkan arah gerakan
            transform.rotation = Quaternion.LookRotation(dir);
            // transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), moveSpeed * Time.deltaTime);

            // 10.2. digunakan untuk memperbarui posisi object yang bergerak berdasarkan kecepatan yang diberikan
            controller.Move(velocity);
        }

        // 11. digunakan untuk dengan mengatur nilai parameter "Speed" pada animator objek berdasarkan kecepatan yang diberikan. 
        animator.SetFloat("Speed", velocity.magnitude);
    }
}
