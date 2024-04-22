using UnityEngine;
using UnityEngine.SceneManagement;      //az se rozdeli obraz vyucujici/manipulator, tak odstranit
using RootMotion.FinalIK;

public class PlayerController : MonoBehaviour
{
    //Statemachine
    public StateMachine stateMachine;
    public StandingState standing;
    public SittingState sitting;
    public AskingState asking;
    public DisbeliefState disbelief;

    public ClapingState claping;
    public AngryState angry;
    //todo - pripravit state
    //[HideInInspector]
    [SerializeField] public bool selected;
    [SerializeField] public bool isAsking;
    [SerializeField] public FullBodyBipedIK finalIK;
    [SerializeField] public InteractionObject rightHandTarget;
    [SerializeField] public GameObject statusSphere;
    //[SerializeField] public LookAtIK lookAt;
    [SerializeField] public Transform headTopPosition;
    //[SerializeField] public int sadValue;
    //[SerializeField] public int angryValue;


    private void Start(){
        selected = false;
        isAsking = false;
        stateMachine = new StateMachine();

        standing = new StandingState(this, stateMachine);
        sitting = new SittingState(this, stateMachine);
        asking = new AskingState(this, stateMachine);
        disbelief = new DisbeliefState(this, stateMachine);

        claping = new ClapingState(this, stateMachine);
        angry = new AngryState(this, stateMachine);

        stateMachine.Initialize(sitting);

        //emocni ukazatele
        //sadValue = 50;
        //angryValue = 50;
    }

    private void Update()
    {
        stateMachine.CurrentState.HandleInput();
        stateMachine.CurrentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.CurrentState.LogicUpdate();

        UpdateTargets(rightHandTarget, headTopPosition);
        UpdateStatus(statusSphere, headTopPosition);
    }

    //upravuji pozice targetu vzhledem k horni pozici hlavy
    public void UpdateTargets(InteractionObject rightHandTarget, Transform headPosition)
    {
        float x = headPosition.transform.position.x + Random.Range(0.004f, 0.006f);
        float y = headPosition.transform.position.y;
        float z = headPosition.transform.position.z;
        rightHandTarget.transform.position = new Vector3(x + 0.08f, y - 0.06f, z - 0.3f);
    }
    //status
    public void UpdateStatus(GameObject statusElement, Transform headPosition)
    {
        float x = headPosition.transform.position.x + Random.Range(0.004f, 0.006f);
        float y = headPosition.transform.position.y;
        float z = headPosition.transform.position.z;
        statusElement.transform.position = new Vector3(x, y + 0.25f, z );

        statusElement.SetActive(selected);
    }

    //Tohle umoznuje vybirat postavy kliknutim mysi na postavu.
    public void OnMouseDown(){
        if(selected == false){
            selected = true;
        }else{
            selected = false;
        }
    }
}
